const PROXY_CONFIG = [
    {
        context: ['/api'],
        target: 'https://localhost:7062/api',
        secure: false,
        loglevel: 'debug',
        changeorigin: true
    }
];

module.exports = PROXY_CONFIG;
