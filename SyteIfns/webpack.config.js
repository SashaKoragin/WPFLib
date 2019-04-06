/// <binding BeforeBuild='Run - Development, Watch - Development' AfterBuild='Watch - Development' />

module.exports = [
require('./webpack.config.vendor.js'),
require('./webpack.ts.css.html.js')
]