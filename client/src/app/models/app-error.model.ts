import { HttpErrorResponse } from '@angular/common/http';
export class AppError {
  public status: string;
  public statusText: string;
  public message: string;
  public returnToHome: boolean = false;

  constructor() {
  }

  public static newNotFoundError(): AppError {
    let appError = new AppError();
    appError.status = "404";
    appError.statusText = "page not found"
    appError.message = "De gevraagde pagina werd niet gevonden";
    appError.returnToHome = true;
    return appError;
  }

  public static newError(error): AppError {
    if (error instanceof HttpErrorResponse) {
      return this.newHttpError(error);
    } else {
      return this.newGenericError(`an unknown error occurred ${error}`);
    }
  }

  private static newHttpError(httpErrorResponse: HttpErrorResponse): AppError {
    let appError = new AppError();
    appError.status = httpErrorResponse.status.toString();
    appError.statusText = httpErrorResponse.statusText;
    appError.message = httpErrorResponse.message;
    return appError;
  }

  public static newGenericError(message: string): AppError {
    let appError = new AppError();
    appError.status = "000";
    appError.statusText = "unknown"
    appError.message = message;
    return appError;
  }
}

