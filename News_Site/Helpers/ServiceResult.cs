﻿namespace News_Site.Helpers
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }

        public static ServiceResult<T> SuccessResult(T data) => new ServiceResult<T> { Success = true, Data = data };

        public static ServiceResult<T> ErrorResult(string errorMessage) => new ServiceResult<T> { Success = false, ErrorMessage = errorMessage };
    }
}
