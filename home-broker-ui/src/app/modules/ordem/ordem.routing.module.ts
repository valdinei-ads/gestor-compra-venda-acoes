import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrdemListComponent } from './components/ordem-list/ordem-list.component';
import { OrdemCreateComponent } from './components/ordem-create/ordem-create.component';
import { OrdemDetailsComponent } from './components/ordem-details/ordem-details.component';

const OrdemRoutes: Routes = [
    {path: 'ordem', component: OrdemListComponent},
    {path: 'ordem/create', component: OrdemCreateComponent},
    {path: 'ordem/details/:id', component: OrdemDetailsComponent}
]

@NgModule({
    imports:[RouterModule.forChild(OrdemRoutes)],
    exports:[RouterModule]
})

export class OrdemRoutingModule {
}