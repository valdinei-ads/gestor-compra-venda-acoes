import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CotacaoListComponent } from './components/cotacao-list/cotacao-list.component';
import { CotacaoEditComponent } from './components/cotacao-edit/cotacao-edit.component';
import { CotacaoDetailsComponent } from './components/cotacao-details/cotacao-details.component';
import { CotacaoCreateComponent } from './components/cotacao-create/cotacao-create.component';

const CotacaoRoutes: Routes = [
    { path: 'cotacao', component: CotacaoListComponent },
    { path: 'cotacao/create', component: CotacaoCreateComponent },
    { path: 'cotacao/edit/:id', component: CotacaoEditComponent },
    { path: 'cotacao/details/:id', component: CotacaoDetailsComponent }
]

@NgModule({
    imports: [RouterModule.forChild(CotacaoRoutes)],
    exports: [RouterModule]
})
export class CotacaoRoutingModule { }