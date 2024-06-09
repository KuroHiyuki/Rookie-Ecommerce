const getToken = (): string | null => {
    return sessionStorage.getItem('authToken');
  };

const apiFetch = async (url: string, options: RequestInit = {}) => {
    const token = getToken();
  
    const headers = {
      ...options.headers,
      'Content-Type': 'application/json',
      'Authorization': ''
    };
  
    if (token) {
      headers['Authorization'] = `Bearer ${token}`;
    }
  
    const response = await fetch(url, {
      ...options,
      headers,
    });
  
    if (!response.ok) {
      throw new Error('Network response was not ok' + response.statusText);
    }
  
    return response;
  };
export default apiFetch;