import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { FaceError, Reshenie, Bdk, Letter, Template, Soprovod } from './app/LoadComponentFull';

const platform = platformBrowserDynamic();
enableProdMode();
platform.bootstrapModule(FaceError);
platform.bootstrapModule(Reshenie);
platform.bootstrapModule(Bdk);
platform.bootstrapModule(Letter);
platform.bootstrapModule(Template);
platform.bootstrapModule(Soprovod)