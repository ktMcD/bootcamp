import { Injectable } from '@angular/core';
import { IBossMonster } from './interfaces/boss';

@Injectable({
  providedIn: 'root'
})
export class BossRepositoryService {

  constructor() { }
  
  getBossMonsters(): IBossMonster[] {
    return [
      {id: 1, name: "Boothstomper",healthPoints: 200, weakness: "fire"},
      {id: 2, name: "Drogfisher",healthPoints: 250, weakness: "water"},
      {id: 3, name: "Piranhaelli",healthPoints: 125, weakness: "cake"},
    ]
  }
}
