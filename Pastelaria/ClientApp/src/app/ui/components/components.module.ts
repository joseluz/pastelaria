import { NgModule } from "@angular/core";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { QtySelectorComponent } from './qty-selector/qty-selector.component';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";

@NgModule({
  providers: [],
  declarations: [
    NavMenuComponent,
    QtySelectorComponent,
  ],
  exports: [
    NavMenuComponent,
    QtySelectorComponent,
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule,
    RouterModule,
  ]
})
export class ComponentsModule {
}
