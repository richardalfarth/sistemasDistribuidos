import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SharedModule } from './_shared/_module/shared.module';
import { EmpresaModule } from './empresa/empresa.module';

@NgModule({
   declarations: [
      AppComponent,
      DashboardComponent,
      NavComponent,
      DashboardComponent,
   ],
   imports: [
      EmpresaModule,
      SharedModule,
      BrowserModule,
      BrowserAnimationsModule,
      AppRoutingModule,
      HttpClientModule,
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
