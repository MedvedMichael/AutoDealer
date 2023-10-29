import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { AnnouncementPageComponent } from './pages/announcement-page/announcement-page.component';
import { EditAnnouncementPageComponent } from './pages/edit-announcement-page/edit-announcement-page.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'announcement/:id', component: AnnouncementPageComponent },
  { path: 'announcement/:id/edit', component: EditAnnouncementPageComponent },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AutoRoutingModule {}
