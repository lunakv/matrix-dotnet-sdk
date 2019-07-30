﻿using System.Net;

namespace Matrix.Backends
{
	public class MatrixRequestError
	{
		public readonly string MatrixError;
		public readonly MatrixErrorCode MatrixErrorCode;
		public readonly HttpStatusCode Status;
		public readonly int RetryAfter;
		public bool IsOk{ get{return MatrixErrorCode == MatrixErrorCode.CL_NONE && Status == HttpStatusCode.OK;}}

		public MatrixRequestError(string merror, MatrixErrorCode code, HttpStatusCode status, int retryAfter = -1){
			MatrixError = merror;
			MatrixErrorCode = code;
			Status = status;
			RetryAfter = retryAfter;
		}

		public string GetErrorString()
		{
			if (string.IsNullOrEmpty(MatrixError))
            {
                return $"{(int)Status}: {Status}";
            }

            return $"{MatrixError}";
		}

		public override string ToString ()
		{
			return GetErrorString ();
		}

		public readonly static MatrixRequestError NO_ERROR = new MatrixRequestError(
			"",
			MatrixErrorCode.CL_NONE,
			HttpStatusCode.OK 
		);
	}
}

