import { NgModule, ModuleWithProviders, SkipSelf, Optional } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  PhoneBookClient,
  EntryClient
    } from './AbsaPhoneBookApi';

import { AbsaPhoneBookApiConfiguration } from './AbsaPhoneBookApiConfiguration';
import { BASE_PATH } from './AbsaPhoneBookApi';
import { environment } from 'src/environments/environment';

@NgModule({
    imports: [CommonModule],
    declarations: [],
    exports: [],
    providers: [
        { provide: BASE_PATH, useValue: environment.apiBaseUri },
        EntryClient,
        PhoneBookClient
    ]
})
export class AbsaPhoneBookApiModule {
    public static forRoot(configurationFactory: () => AbsaPhoneBookApiConfiguration): ModuleWithProviders<AbsaPhoneBookApiModule> {
        return {
            ngModule: AbsaPhoneBookApiModule,
            providers: [{ provide: AbsaPhoneBookApiConfiguration, useFactory: configurationFactory }]
        };
    }

    constructor(@Optional() @SkipSelf() parentModule: AbsaPhoneBookApiModule) {
        if (parentModule) {
            throw new Error('ApiModule is already loaded. Import your base AppModule only.');
        }
    }
}
