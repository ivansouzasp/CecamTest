import { Component, NgModule, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/services/cliente.services';
import { AppComponent } from './../../app.component';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { cnpj } from 'cpf-cnpj-validator';
@Component({
  selector: 'app-cliente-detail',
  templateUrl: './cliente-detail.component.html',
  styleUrls: ['./cliente-detail.component.css']
})
export class ClienteDetailComponent implements OnInit {
  id: any;
  showCNPJValidation = false;
  showRazaoSocialValidation = false;
  showDataCadastroValidation = false;
  showDataCadastroIsValid = false;
  isVisibleValidation = false;
  showCNPJIsValid = false;
  clienteEntity = {
    codigo: 0,
    razaoSocial: '',
    cnpj: '',
    dataCadastro: ''
  };

  submitted = false;
  isVisibleDetail = false;
  constructor(private clienteService: ClienteService, private appComp: AppComponent, private activityRoute: ActivatedRoute, private route: Router) { }

  ngOnInit(): void {
    this.loadCliente();
  }

  saveCliente(): void{
    if (this.validateForm()){
      let year = '';
      let month = '';
      let day = '';
      debugger;
      if (this.clienteEntity.dataCadastro == ''){
        year = '0001';
        month = '01';
        day = '01';
      }
      else{
        year = this.clienteEntity.dataCadastro.substr(6, 4);
        month = this.clienteEntity.dataCadastro.substr(3,2);
        day = this.clienteEntity.dataCadastro.substr(0, 2);
      }
      let dateCadastro = year + '-' + month + '-' + day + 'T00:00:00';
      const data = {
        codigo: this.clienteEntity.codigo,
        razaoSocial: this.clienteEntity.razaoSocial,
        cnpj: this.clienteEntity.cnpj,
        dataCadastro: dateCadastro
      };
  
      this.id = this.activityRoute.snapshot.paramMap.get('codigo');
      debugger;
      if (this.id == 0){
        this.clienteService.create(data)
        .subscribe(
          response => {
           console.log(response);
           this.route.navigate(['listclientes']);
           //this.submitted = true;
         },
          error => {
            console.log(error);
          });
      }
      else{
        this.clienteService.update(data)
        .subscribe(
          response => {
            debugger;
           console.log(response);
           this.route.navigate(['listclientes']);
           //this.submitted = true;
         },
          error => {
            console.log(error);
          });
      }
    }
  }
  validateForm(): boolean{
    this.showCNPJValidation = false;
    this.showRazaoSocialValidation = false;
    this.showDataCadastroValidation = false;
    this.showDataCadastroIsValid = false;
    this.isVisibleValidation = false;
    this.showCNPJIsValid = false;
    let resultVal = true;
    if (this.clienteEntity.cnpj == ''){
      this.isVisibleValidation = true;
      this.showCNPJValidation = true;
      resultVal = false;
    }
    else{
      this.showCNPJIsValid = this.validateCNPJ(this.clienteEntity.cnpj) ? false : true;
      if (this.showCNPJIsValid){
        this.isVisibleValidation = true;
        resultVal = false;
      }
      else{
        this.isVisibleValidation = false;
        resultVal = true;
      }
    }
    if (this.clienteEntity.razaoSocial == ''){
      this.isVisibleValidation = true;
      this.showRazaoSocialValidation = true;
      resultVal = false;
    }
    if (this.clienteEntity.dataCadastro == ''){
      this.isVisibleValidation = true;
      this.showDataCadastroValidation = true;
      resultVal = false;
    }
    else{
      if (!this.validateDate(this.clienteEntity.dataCadastro)){
        this.isVisibleValidation = true;
        this.showDataCadastroIsValid = true;
        resultVal = false;
      }
    }
    
    return resultVal;
  }
  newCliente(): void {
    this.submitted = false;
    this.isVisibleDetail = true;
    this.clienteEntity = {
      codigo: 0,
      razaoSocial: '',
      cnpj: '',
      dataCadastro: ''
    };
  }
  loadCliente(): void{
    this.id = this.activityRoute.snapshot.paramMap.get('codigo');
    if (this.id > 0){
      this.clienteService.get(this.id)
      .subscribe(
        response => {
          this.clienteEntity = response;
          let year = response.dataCadastro.substr(0, 4);
          let month = response.dataCadastro.substr(5,2);
          let day = response.dataCadastro.substr(8, 2);
          let dateCadastro = day + '-' + month + '-' + year;
          this.clienteEntity.dataCadastro = dateCadastro;
        },
        error => {
          console.log(error);
        });
      }
  }
  backToList(): void{
    this.appComp.isVisible = true;
  }
  validateDate(dateValue: any): boolean{
    let resultValDate = true;
    var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
    if (!(date_regex.test(dateValue))) {
      resultValDate = false;
    }
    return resultValDate;
  }
  validateCNPJ(cnpjNumber: string): boolean{
    return cnpj.isValid(cnpjNumber)
  }
}
