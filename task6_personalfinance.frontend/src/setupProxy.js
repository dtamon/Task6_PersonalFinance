const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/api/account",
    "/api/expense",
    "/api/income",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7138',
        secure: false
    });

    app.use(appProxy);
};
