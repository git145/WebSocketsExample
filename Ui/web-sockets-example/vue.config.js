// vue.config.js

module.exports = {
    pluginOptions: {
        electronBuilder: {
            builderOptions: {
                "artifactName": "web-sockets-test.exe",
                "win": {
                    "target": [
                        {
                            "target": "nsis",
                            "arch": [
                                "x64"
                            ]
                        }
                    ]
                }
            }
        }
    }
}