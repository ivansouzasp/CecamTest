import { Component, NgModule, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/services/cliente.services';
import { AppComponent } from './../../app.component';

@Component({
  selector: 'app-cliente-detail',
  templateUrl: './cliente-detail.component.html',
  styleUrls: ['./cliente-detail.component.css']
})
export class ClienteDetailComponent implements OnInit {
  clienteEntity = {
    codigo: 0,
    razaosocial: '',
    cnpj: '',
    datacadastro: ''
  };

  submitted = false;
  isVisibleDetail = false;
  constructor(private clienteService: ClienteService, private appComp: AppComponent) { }

  ngOnInit(): void {
  }

  addCliente(): void{
    const data = {
      codigo: this.clienteEntity.codigo,
      razaosocial: this.clienteEntity.razaosocial,
      cnpj: this.clienteEntity.cnpj,
      datacadastro: this.clienteEntity.datacadastro
    };

    this.clienteService.create(data)
    .subscribe(
      response => {
        console.log(response);
        this.submitted = true;
      },
      error => {
        console.log(error);
      });
  }

  newCliente(): void {
    
    this.submitted = false;
    this.isVisibleDetail = true;
    this.clienteEntity = {
      codigo: 0,
      razaosocial: '',
      cnpj: '',
      datacadastro: ''
    };
  }
  backToList(): void{
    this.appComp.isVisible = true;
  }
}
