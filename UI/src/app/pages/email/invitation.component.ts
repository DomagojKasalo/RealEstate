import { Component, OnInit } from '@angular/core';
import { SendMailRequest } from 'src/app/shared/model/invitation.model';
import { InvitationService } from 'src/app/shared/services/modules/invitation.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-invitation',
  templateUrl: './invitation.component.html',
  styleUrls: ['./invitation.component.scss']
})
export class InvitationComponent implements OnInit {
  
  request: SendMailRequest = new SendMailRequest();

  constructor(
    private invitationService: InvitationService,
    private router: Router,
    ) { }

  ngOnInit(): void {
  }

  sendInvitation(): void {
    this.invitationService.sendInvitation(this.request).subscribe(
      res => {
        console.log('Invitation sent successfully');
        this.router.navigateByUrl('/home');
      },
      err => {
        console.log('Error sending invitation');
      }
    );
  }
}
