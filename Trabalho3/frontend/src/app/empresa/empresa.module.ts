
import { EmpresaRoutingModule } from './empresa-routing.module';
import { EmpresaComponent } from "./empresa.component";
import { SharedModule } from '../_shared/_module/shared.module';
import { NgModule } from '@angular/core';


@NgModule({
  declarations: [
    EmpresaComponent
  ],
  imports: [
    SharedModule,
    EmpresaRoutingModule
  ]
})
export class EmpresaModule { }
