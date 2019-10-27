import { Component, OnInit } from '@angular/core';
import { ItemService } from '../../services/items.service';
import { Item } from '../../models/Item';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit  {

    items: Item[] = [];
    constructor(public itemService: ItemService) { }

    ngOnInit(): void {
        this.itemService.GetAll().then((data: Item[]) => {
            this.items = data;
        }).catch(e => {
            console.log(e);
        });
    }
}
