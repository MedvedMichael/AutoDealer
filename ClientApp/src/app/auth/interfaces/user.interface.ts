export interface LoginCredentials {
  email: string;
  password: string;
}

export interface RegisterCredentials extends LoginCredentials {
  name: string;
  surname: string;
}

type User = Omit<RegisterCredentials, 'password'> & {
  id: string;
};

export default User;
