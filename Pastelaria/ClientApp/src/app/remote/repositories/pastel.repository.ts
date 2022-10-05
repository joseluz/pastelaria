import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Pastel } from "../../model/pastel.model";
import { PastelClient, PastelResouce } from "../gateway/web-api.client";
import { map } from 'rxjs/operators';

@Injectable()
export class PastelRepository {

  constructor(private pastelClient: PastelClient) {
  }

  findAllFlavors(): Observable<Array<Pastel>> {
    return this.pastelClient.get()
      .pipe(
        map((pastels: PastelResouce[]) => pastels.map(p => new Pastel({ name: p.name ?? "", ingredients: p.ingredients ?? "", isSweet: p.isSweet, })))
      );
  }
}
