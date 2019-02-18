import { Injectable } from '@angular/core';
declare let alertify: any; // to use the 3rd party global lib, declear it locally

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {
  constructor() {}
  // the service's method we defined: user comfirm(the msg, the function)
  confirm(message: string, okCallBack: () => any) {
    alertify.confirm(message, function(e) { // e: client click event
      if (e) {
        okCallBack(); // use callback func if user click sth
      } else {}
    });
  }

  // service method we defined: notify user success
  success(message: string) {
    alertify.success(message);
  }

  // service's method we defined: notify user some error
  error(message: string) {
    alertify.error(message);
  }

  // service's method we defined: warn user
  warning(message: string) {
    alertify.warning(message);
  }

  // service's method we defined: show message to user
  message(message: string) {
    alertify.message(message);
  }
}

