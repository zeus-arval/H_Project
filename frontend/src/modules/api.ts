import type { Ref } from 'vue';
import { ref } from 'vue';

export type ApiRequest = () => Promise<void>;

export interface UseableApi<T> {
  response: Ref<T | undefined>;
  request: ApiRequest;
}

const apiUrl = 'https://localhost:7157/api/';

export function useApi<T>(
  url: RequestInfo,
  options?: RequestInit,
): UseableApi<T> {
  const response: Ref<T | undefined> = ref();

  const request: ApiRequest = async () => {
    const res = await fetch(apiUrl + url, options);    
    const data = await res.json();
    response.value = data;
  };

  return { response, request };
}

export function useApiRawRequest(url: RequestInfo, options?: RequestInit) {
  const request: () => Promise<Response> = async () => {
    return await fetch(apiUrl + url, options);
  };
  return request;
}
