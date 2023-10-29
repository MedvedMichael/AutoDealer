import { UserState, userFeatureKey } from '../auth/store/reducers/user.reducer';
import { AutoState, autoFeatureKey } from '../auto/store/reducers/auto.reducer';

export interface State {
  [userFeatureKey]: UserState;
  [autoFeatureKey]: AutoState;
}
