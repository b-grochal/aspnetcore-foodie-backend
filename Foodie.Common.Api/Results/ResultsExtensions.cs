using Foodie.Common.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Foodie.Common.Api.Results
{
    public static class ResultsExtensions
    {
        public static IActionResult Match(this Result result, Func<IActionResult> onSuccess, Func<Result, IActionResult> onFailure)
        {
            return result.IsSucess ? onSuccess() : onFailure(result);
        }
    }
}
