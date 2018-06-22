import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { enableProdMode } from '@angular/core';
import { FaceError,Trebovanie } from "./app/LoadComponentFull";

const platform = platformBrowserDynamic();
enableProdMode();
platform.bootstrapModule(FaceError);
platform.bootstrapModule(Trebovanie);

