import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { enableProdMode } from '@angular/core';
import { FaceError, Reshenie, Bdk, Letter } from "./app/LoadComponentFull";
var platform = platformBrowserDynamic();
enableProdMode();
platform.bootstrapModule(FaceError);
platform.bootstrapModule(Reshenie);
platform.bootstrapModule(Bdk);
platform.bootstrapModule(Letter);
//# sourceMappingURL=main.js.map