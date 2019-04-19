/// <binding BeforeBuild='Run - Development' ProjectOpened='Watch - Development' />
module.exports = [
require('./webpack.config.vendor.js'),
require('./webpack.ts.css.html.js')
]