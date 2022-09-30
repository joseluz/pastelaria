import { CommonModule } from "@angular/common";
import { PastelService } from "./pastel.services";
import { NgModule } from "@angular/core";

@NgModule({
  declarations: [],
  providers: [
    PastelService,
  ],
  imports: [
    CommonModule
  ]
})
export class ServicesModule {
}
