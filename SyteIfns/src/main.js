import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { enableProdMode } from '@angular/core';
import { FaceError, Reshenie } from "./app/LoadComponentFull";
var platform = platformBrowserDynamic();
enableProdMode();
platform.bootstrapModule(FaceError);
platform.bootstrapModule(Reshenie);
//# sourceMappingURL=main.js.map