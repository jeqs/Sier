import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { HttpClientService } from '../core/services/httpclient.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-detalleproducto',
  templateUrl: './detalleproducto.component.html',
  styleUrls: ['./detalleproducto.component.css']
})
export class DetalleproductoComponent implements OnInit {
  formDetalleProducto: FormGroup;
  detalleProducto: any;
  valorTotal: number;
  valorIVA: number;
  precio: number;
  producto: any;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private httpClientService: HttpClientService) { }

  ngOnInit(): void {
    this.producto = {
      id: 0,
      nombre: '',
      descripcion: '',
      precio: 0
    } as any;

    this.detalleProducto = {
      idDetalleProducto: 0,
      idProducto: 0,
      nombre: '',
      descripcion: '',
      precio: 0
    } as any;

    this.formDetalleProducto = this.formBuilder.group({
      cantidad: 0,
    });

    this.activatedRoute.paramMap.subscribe(params => {
      if (params.get('id') !== '0') {
        this.get(params.get('id'));
      }
    });
  }

  async get(id: any) {
    this.producto = await this.httpClientService.get("Producto", id);

    this.detalleProducto = await this.httpClientService.getDetallePorProducto("DetalleProducto", id);
    this.formDetalleProducto = this.formBuilder.group({
      cantidad: this.detalleProducto.cantidad,
    });

    this.detalleProducto.idProducto = this.producto.id;
    this.precio = this.producto.precio;
    let iva = (this.producto.precio * this.detalleProducto.cantidad * environment.IVA) / 100;
    this.valorIVA = iva;
    this.valorTotal = this.producto.precio * this.detalleProducto.cantidad + iva;
  }

  async crearDetalleProducto() {
    this.detalleProducto.cantidad = this.formDetalleProducto.value.cantidad;
    this.detalleProducto.valorIva = this.valorIVA;
    this.detalleProducto.valorTotal = this.valorTotal;

    if (this.detalleProducto.idDetalleProducto == 0 || this.detalleProducto.idDetalleProducto == undefined) {
      this.detalleProducto.idDetalleProducto = 0;
      this.detalleProducto = await this.httpClientService.create("DetalleProducto", this.detalleProducto);
    }
    else {
      this.detalleProducto = await this.httpClientService.update("DetalleProducto", this.detalleProducto);
    }

    Swal.fire({
      title: 'Guardar!',
      text: 'Registro guardado con éxito',
      icon: 'success',
      confirmButtonText: 'Aceptar'
    });

    this.router.navigate(['/productos']);
  }

  calcularIVA() {
    this.precio = this.producto.precio;
    let iva = (this.producto.precio * this.formDetalleProducto.value.cantidad * environment.IVA) / 100;
    this.valorIVA = iva;
    this.valorTotal = this.producto.precio * this.formDetalleProducto.value.cantidad + iva;
  }

  cancelar() {
    this.router.navigate(['/productos']);
  }

}
