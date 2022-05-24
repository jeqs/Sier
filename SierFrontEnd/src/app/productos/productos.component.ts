import { Component, OnInit } from '@angular/core';
import { HttpClientService } from '../core/services/httpclient.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
  displayedColumns: string[] = ['id', 'nombre', 'descripcion', 'precio', 'actions'];
  productos: any;

  constructor(private httpClientService: HttpClientService) { }

  ngOnInit(): void {
    this.getProductos();
  }

  async getProductos() {
    this.productos = await this.httpClientService.getAll("Producto");
  }

}
