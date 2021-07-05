import { Component, ViewChildren, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/services/cliente.services';
import { AppComponent } from './../../app.component';

@Component({
  selector: 'app-cliente-list',
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {
  listClientes: any;
  constructor(private clienteService: ClienteService, private appComp: AppComponent) { }

  ngOnInit(): void {
    this.retrieveClientes();
  }

  retrieveClientes(): void {
    this.clienteService.getAll()
      .subscribe(
        data => {
          this.listClientes = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }
  hideComponent(): void{
    this.appComp.isVisible = false;    
  }
  deleteCliente(id: number): void{
    this.clienteService.delete(id)
    .subscribe(
      data => {
        console.log(data);
        this.retrieveClientes();
      },
      error => {
        console.log(error);
      });
  }
}
