import { Component, NgModule, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/services/cliente.services';
import { AppComponent } from './../../app.component';
import { ActivatedRoute } from '@angular/router'
@Component({
  selector: 'app-cliente-detail',
  templateUrl: './cliente-detail.component.html',
  styleUrls: ['./cliente-detail.component.css']
})
export class ClienteDetailComponent implements OnInit {
  id: any;
  clienteEntity = {
    codigo: 0,
    razaosocial: '',
    cnpj: '',
    datacadastro: ''
  };

  submitted = false;
  isVisibleDetail = false;
  constructor(private clienteService: ClienteService, private appComp: AppComponent, private route: ActivatedRoute) { }

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
  loadCliente(): void{
    this.id = this.route.snapshot.paramMap.get('codigo');
    this.clienteService.get(this.id)
    .subscribe(
      response => {
        this.clienteEntity.codigo = response[0].codigo;
        this.clienteEntity.razaosocial = response[0].razaoSocial;
        this.clienteEntity.cnpj = response[0].cnpj;
        this.clienteEntity.datacadastro = response[0].dataCadastro;
      },
      error => {
        console.log(error);
      });
  }
  backToList(): void{
    this.appComp.isVisible = true;
  }
}
