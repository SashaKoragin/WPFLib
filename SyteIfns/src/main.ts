import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { Maining } from './app/NgModule/Main/NgMain';

const platform = platformBrowserDynamic();
enableProdMode();
platform.bootstrapModule(Maining);