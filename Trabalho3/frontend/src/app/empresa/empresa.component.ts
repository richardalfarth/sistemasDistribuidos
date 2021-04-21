import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Empresa } from '../_modules/Empresa';
import { EmpresaService } from '../_services/empresa.service';


@Component({
  selector: 'app-empresa',
  templateUrl: './empresa.component.html',
  styleUrls: ['./empresa.component.css']
})
export class EmpresaComponent implements OnInit {

  empresas: Empresa[];
  empresa: Empresa;
  empresasFiltradas: Empresa[];
  _filtroLista = '';
  registerForm: FormGroup;
  modoSalvar = 'post';
  bodyDeletarEmpresa = '';
  titulo = 'Empresas';
  id: number;
  dataEvento: string;
  dataAtual: string;


  constructor(private empresaService: EmpresaService,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private toastr: ToastrService) {
    this.localeService.use('pt-br');
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }
  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.empresasFiltradas = this.filtroLista ? this.filtrarEmpresa(this.filtroLista) : this.empresas;
  }

  ngOnInit() {
    this.validation();
    this.getEmpresas();
  }

  filtrarEmpresa(filtrarPor: string): Empresa[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.empresas.filter(
      Empresa => Empresa.nomeFantasia.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || Empresa.cnpj.indexOf(filtrarPor) !== -1
    );
  }
  editarEmpresa(empresa: Empresa, template: any) {
    this.modoSalvar = 'put';
    this.openModal(template);
    this.id = empresa.id;
    this.empresa = Object.assign({}, empresa);
    this.registerForm.patchValue(this.empresa);
  }
  novaEmpresa(template: any) {
    this.modoSalvar = 'post';
    this.openModal(template);
  }
  excluirEmpresa(empresa: Empresa, template: any) {
    this.openModal(template);
    this.empresa = empresa;
    this.bodyDeletarEmpresa = `Tem certeza que deseja excluir o Empresa: ${empresa.nomeFantasia}, Código: ${empresa.id}`;
  }
  confirmeDelete(template: any) {
    this.empresaService.excluirEmpresa(this.empresa.id).subscribe(
      () => {
        template.hide();
        this.getEmpresas();
        this.toastr.success('Deletado com Sucesso!');
      }, error => {
        this.toastr.error('Erro ao Tentar deletar!');
      }
    );
  }
  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.modoSalvar === 'post') {
        this.empresa = Object.assign(this.registerForm.value);
        this.empresaService.adicionarEmpresa(this.empresa).subscribe(
          (novaEmpresa: Empresa) => {
            template.hide();
            this.getEmpresas();
            this.toastr.success('Inserido com Sucesso!');
          }, error => {
            this.toastr.error(`Erro ao Inserir: ${error.error}`);
          }
        );
      } else {
        this.empresa = Object.assign({ id: this.id, userId: sessionStorage.getItem('id') }, this.registerForm.value);
        this.empresaService.editarEmpresa(this.empresa).subscribe(
          () => {
            template.hide();
            this.getEmpresas();
            this.toastr.success('Editado com Sucesso!');
          }, error => {
            this.toastr.error(`Erro ao Editar: ${error}`);
          }
        );
      }
    }
  }
  validation() {
    this.registerForm = this.fb.group({
      nomeFantasia: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      cnpj: ['', [Validators.required, Validators.minLength(14), Validators.maxLength(14)]],
      uf: ['', Validators.required],
    });
  }
  getEmpresas() {
    this.empresaService.obterEmpresa().subscribe(
      (_empresas: Empresa[]) => {
        this.empresas = _empresas;
        this.empresasFiltradas = this.empresas;
      }, error => {
        this.toastr.error(`Erro ao tentar Carregar Empresas: ${error}`);
      });
  }
  obterTipoEstado(uf: string): string {
    switch (uf.toString()) {
      case '1': return 'Acre';
      case '2': return 'Alagoas';
      case '3': return 'Amapá';
      case '4': return 'Amazonas';
      case '5': return 'Bahia';
      case '6': return 'Ceará';
      case '7': return 'Distrito Federal';
      case '8': return 'Espírito Santo';
      case '9': return 'Goiás';
      case '10': return 'Maranhão';
      case '11': return 'Mato Grosso';
      case '12': return 'Mato Grosso do Sul';
      case '13': return 'Minas Gerais';
      case '14': return 'Pará';
      case '15': return 'Paraíba';
      case '16': return 'Paraná';
      case '17': return 'Pernambuco';
      case '18': return 'Piauí';
      case '19': return 'Rio de Janeiro';
      case '20': return 'Rio Grande do Norte';
      case '21': return 'Rio Grande do Sul';
      case '22': return 'Rondônia';
      case '23': return 'Roraima';
      case '24': return 'Santa Catarina';
      case '25': return 'São Paulo';
      case '26': return 'Sergipe';
      case '27': return 'Tocantins';
      case '28': return 'Extrangeiro';
    }
  }
}


