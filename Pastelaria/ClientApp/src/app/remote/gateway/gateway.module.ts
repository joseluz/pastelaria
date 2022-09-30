import { NgModule } from '@angular/core';

@NgModule({
  providers: [
    {
      provide: 'API_BASE_URL',
      useFactory: getBaseUrl,
    },
  ]
})
export class GatewaysModule {
}

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
