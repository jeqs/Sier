import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClientService } from '../core/services/httpclient.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {
  formProducto: FormGroup;
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

    this.formProducto = this.formBuilder.group({
      nombre: '',
      descripcion: '',
      precio: 0
    });

    this.activatedRoute.paramMap.subscribe(params => {
      if (params.get('id') !== '0') {
        this.get(params.get('id'));
      }
    });
  }

  async get(id: any) {
    this.producto = await this.httpClientService.get("Producto", id);
    this.formProducto = this.formBuilder.group({
      nombre: this.producto.nombre,
      descripcion: this.producto.descripcion,
      precio: this.producto.precio
    });
  }

  async crearProducto() {
    this.producto.nombre = this.formProducto.value.nombre;
    this.producto.descripcion = this.formProducto.value.descripcion;
    this.producto.precio = this.formProducto.value.precio;

    if (this.producto.id == 0) {
      this.producto = await this.httpClientService.create("Producto", this.producto);
    }
    else {
      this.producto = await this.httpClientService.update("Producto", this.producto);
    }

    Swal.fire({
      title: 'Guardar!',
      text: 'Registro guardado con éxito',
      icon: 'success',
      confirmButtonText: 'Aceptar'
    });

  }

  cancelar() {
    this.router.navigate(['/productos']);
  }

}
