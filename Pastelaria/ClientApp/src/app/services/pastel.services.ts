import { Injectable } from "@angular/core";
import { PastelRepository } from "../remote/repositories/pastel.repository";

@Injectable()
export class PastelService {
  constructor(private pastelRepository: PastelRepository) {

  }
}
