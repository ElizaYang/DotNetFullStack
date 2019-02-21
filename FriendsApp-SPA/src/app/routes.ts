import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { LikesListComponent } from './likes-list/likes-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_routesGuards/auth.guard';

// Routes appRoutes conatain a list of path<->component relations;
export const appRoutes: Routes = [
    {path: '', component: HomeComponent}, // localhost:4200
    {
        path: '', // localhost:4200/path/childrenPath
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'members', component: MemberListComponent},
            {path: 'likes', component: LikesListComponent},
            {path: 'messages', component: MessagesComponent},
        ]
    },
    // anypath not in above, wildcard redirect to home
    {path: '**', redirectTo: '', pathMatch: 'full'}
];

