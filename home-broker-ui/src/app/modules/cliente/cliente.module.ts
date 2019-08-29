import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../../shared/shared.module';


//  Components
import { ClienteListComponent } from './components/cliente-list/cliente-list.component';
import { ClienteCreateComponent } from './components/cliente-create/cliente-create.component';
import { ClienteEditComponent } from './components/cliente-edit/cliente-edit.component';
import { ClienteDetailsComponent } from './components/cliente-details/cliente-details.component';

//  Route Module
import { ClienteRoutingModule } from './cliente.routing.module';

@NgModule({
  declarations: [
    ClienteListComponent,
    ClienteCreateComponent,
    ClienteEditComponent,
    ClienteDetailsComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ClienteRoutingModule,
    SharedModule
  ]
})
export class ClienteModule { }