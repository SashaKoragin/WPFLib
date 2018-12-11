import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/LoadComponentFull';
var platform = platformBrowserDynamic();
enableProdMode();
platform.bootstrapModule(AppModule);
//platform.bootstrapModule(FaceError);
//platform.bootstrapModule(Reshenie);
//platform.bootstrapModule(Bdk);
//platform.bootstrapModule(Letter);
//platform.bootstrapModule(Template);
//platform.bootstrapModule(Soprovod);
//platform.bootstrapModule(AnalizNaloga);
//# sourceMappingURL=main.js.map