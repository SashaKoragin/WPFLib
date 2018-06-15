import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { enableProdMode } from '@angular/core';
import { AppModule } from "./app/app.module";
var platform = platformBrowserDynamic();
enableProdMode();
platform.bootstrapModule(AppModule);
//# sourceMappingURL=main.js.map