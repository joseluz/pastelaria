export class Pastel {
  name: string = '';
  ingredients: string = '';
  isSweet: boolean = false;
  qty: number = 0;

  constructor(init?: Partial<Pastel>) {
    Object.assign(this, init);
  }
}
