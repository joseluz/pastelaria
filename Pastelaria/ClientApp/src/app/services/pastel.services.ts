import { Injectable } from "@angular/core";
import { PastelRepository } from "../remote/repositories/pastel.repository";
import { Observable } from "rxjs";
import { Pastel } from "../model/pastel.model";

@Injectable()
export class PastelService {
  constructor(private pastelRepository: PastelRepository) {

  }

  findAllFlavors(): Observable<Array<Pastel>> {
    return this.pastelRepository.findAllFlavors();
  }
}
