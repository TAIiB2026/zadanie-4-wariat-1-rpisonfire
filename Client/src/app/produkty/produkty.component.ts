import { Component, inject, OnInit } from '@angular/core';
import { GET_DATA_TOKEN } from '../tokens/get-data.token';
import { ProduktClass } from '../classes/produkt.class';

@Component({
  selector: 'taiib2-produkty',
  standalone: false,
  templateUrl: './produkty.component.html',
  styles: ``
})
export class ProduktyComponent implements OnInit {
  private readonly service = inject(GET_DATA_TOKEN);
  public data: ProduktClass[] = [];

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.service.Get().subscribe(items => this.data = items);
  }

  delete(id: number) {
    this.service.Delete(id).subscribe(() => this.loadData());
  }
}
