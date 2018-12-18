var Path = require('path');
var Webpack = require('webpack');
var UglifyJsPlugin = require('uglifyjs-webpack-plugin'); // плагин минимизации
//var MiniCssExtractPlugin = require("mini-css-extract-plugin");
//var OptimizeCssAssetsPlugin = require('optimize-css-assets-webpack-plugin');
module.exports = {
    mode: "development",
    devServer: {
        overlay: true
    },
    entry: {
        'polyfills': './src/polyfills.ts',
        'app': './src/main.ts'
    },
    output: {
        path: Path.resolve(__dirname, './public'), // путь к каталогу выходных файлов - папка public
        publicPath: '/public/',
        filename: '[name].js' // название создаваемого файла
    },
    resolve: {
        extensions: ['.ts', '.js']
    },
    module: {
        rules: [//загрузчик для ts
            {
                test: /\.ts$/, // определяем тип файлов
                use: [
                    {
                        loader: 'awesome-typescript-loader',
                        options: { configFileName: Path.resolve(__dirname, 'tsconfig.json') }
                    },
                    'angular2-template-loader'
                ]
            }, {
                test: /\.html$/,
                loader: 'html-loader'
            }, {
                test: /\.css$/,
                loader: 'raw-loader'
            },
            {
                test: /.*\.(png|woff|woff2|eot|ttf|svg|jpg)(\?|$)/,
                use: [
                        {
                            loader: 'file-loader',
                            options: {
                                outputPath: './images/',
                                name: '[name].[ext]'
                            }
                        }
                ]
            }
                                     //{
                                     //    test: /\.(png|jp(e*)g|svg)$/,
                                     //    use: [{
                                     //        loader: 'url-loader',
                                     //        options: {
                                     //            limit: 8000, // Convert images < 8kb to base64 strings
                                     //            name: 'images/[hash]-[name].[ext]'
                                     //        }
                                     //    }]
                                     //}
        ]
    },
    plugins: [
        new Webpack.ContextReplacementPlugin(
            /angular(\\|\/)core/,
            Path.resolve(__dirname, 'src'), // каталог с исходными файлами
            {} // карта маршрутов
        ),
        new UglifyJsPlugin(),
        new Webpack.ProvidePlugin({
          $:'jquery/dist/jquery.min.js',
          jQuery: 'jquery/dist/jquery.min.js',
          'window.jQuery': 'jquery/dist/jquery.min.js'
        })
    ],
    devtool: 'source-map'
};

