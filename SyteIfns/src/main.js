import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/LoadComponentFull';
var platform = platformBrowserDynamic();
enableProdMode();
platform.bootstrapModule(AppModule);
//# sourceMappingURL=main.js.map