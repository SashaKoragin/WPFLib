var IsDevBuild = process.argv.indexOf('--env.prod') < 0;
var Path = require('path');
var Webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var ExtractCss = new ExtractTextPlugin('vendor.css');

module.exports = {
    resolve: {
        extensions: ['.js']
    },
    module: {
        rules: [
            {
                test: /\.css(\?|$)/, loader: ExtractTextPlugin.extract({
                    fallback: "style-loader",
                    use: "css-to-string-loader!css-loader"
                })
            }
        ]
    },
    entry: {
        vendor: [
                '@angular/animations',
                '@angular/common',
                '@angular/compiler',
                '@angular/core',
                '@angular/forms',
                '@angular/common/http',
                '@angular/platform-browser',
                '@angular/platform-browser-dynamic',
                '@angular/router',
                '@angular/material',
                '@angular/material/prebuilt-themes/deeppurple-amber.css',
                'bootstrap',
                'bootstrap/dist/css/bootstrap.css',
                'es6-shim',
                'es6-promise',
                'event-source-polyfill',
                'jquery',
                'zone.js'
        ]
    },
    output: {
        path: Path.join(__dirname, 'public'),
        filename: '[name].js',
        library: '[name]_[hash]'
    },
    plugins: [
        ExtractCss,
        new Webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' }), // Maps these identifiers to the jQuery package (because Bootstrap expects it to be a global variable)
        new Webpack.optimize.OccurrenceOrderPlugin(),
        new Webpack.DllPlugin({
            path: Path.join(__dirname, 'public', '[name]-manifest.json'),
            name: '[name]_[hash]'
        })
    ].concat(IsDevBuild ? [] : [
        new Webpack.optimize.UglifyJsPlugin({ compress: { warnings: false } })
    ]),

};