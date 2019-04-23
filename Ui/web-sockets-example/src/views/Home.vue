<template>
    <div>
        <section>
            <h2>WebSockets</h2>

            <ul>
                <li>
                    <button @click="openWebSocket()">Open {{ webSocket.name }}</button>
                </li>

                <li>
                    <button @click="closeWebSocket()">Close {{ webSocket.name }}</button>
                </li>
            </ul>
        </section>

        <section>
            <h2>Feedback</h2>

            <h3>{{ feedback }}</h3>
        </section>

        <section>
            <h2>Messages</h2>

            <button @click="clearMessages()">Clear messages</button>

            <ul>
                <li v-for="message in messages" :key="message.id">{{ message }}</li>
            </ul>
        </section>
    </div>
</template>

<script lang="ts">
import { Component, Vue, Provide } from "vue-property-decorator";

import { WebSocketEnum } from "../enums/WebSocketEnum";
import IWebSocket from "../interfaces/IWebSocket";

@Component({})
export default class Home extends Vue {
    private userSettings = require("../assets/appsettings.json").UserSettings;

    private domain = this.userSettings.domain;

    @Provide() private webSocket: IWebSocket = {
        name: "WebSockets",
        type: WebSocketEnum.Default
    };

    @Provide() private messages: string[] = [];

    @Provide() private feedback: string = "None";

    public openWebSocket(): void {
        const webSocketName: string | undefined = this.webSocket.name;

        if (
            !this.webSocket.webSocket ||
            this.webSocket.webSocket.readyState !== WebSocket.OPEN
        ) {
            switch (this.webSocket.type) {
                case WebSocketEnum.Default: {
                    this.webSocket.webSocket = new WebSocket(
                        `ws://${this.domain}/default`
                    );

                    break;
                }

                default: {
                    break;
                }
            }
        } else {
            this.feedback = `The ${webSocketName} is already connected`;
        }

        if (this.webSocket.webSocket !== undefined) {
            this.webSocket.webSocket.onopen = () => {
                this.feedback = `Connection to the ${webSocketName} is successful`;
            };

            this.webSocket.webSocket.onmessage = event => {
                this.messages.push(event.data);
            };

            this.webSocket.webSocket.onclose = () => {
                this.feedback = `Connection to the ${webSocketName} is closed`;
            };

            this.webSocket.webSocket.onerror = () => {
                this.feedback = `Connection to the ${webSocketName} failed`;
            };
        } else {
            this.feedback = `${webSocketName} is not defined`;
        }
    }

    private closeWebSocket(): void {
        const webSocketName: string | undefined = this.webSocket.name;

        if (
            !this.webSocket.webSocket ||
            this.webSocket.webSocket.readyState !== WebSocket.OPEN
        ) {
            this.feedback = `The ${webSocketName} is not connected`;
        } else {
            this.webSocket.webSocket.close(
                1000,
                `Closing the ${webSocketName} from the client`
            );
        }
    }

    private clearMessages(): void {
        this.messages = [];
    }
}
</script>
