﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NHibernate.Impl
{
	public abstract partial class FutureBatch<TQueryApproach, TMultiApproach>
	{

		private async Task<IList> GetResultsAsync(CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			if (results != null)
			{
				return results;
			}
			var multiApproach = CreateMultiApproach(isCacheable, cacheRegion);
			for (int i = 0; i < queries.Count; i++)
			{
				AddTo(multiApproach, queries[i], resultTypes[i]);
			}
			results = await (GetResultsFromAsync(multiApproach, cancellationToken)).ConfigureAwait(false);
			ClearCurrentFutureBatch();
			return results;
		}

		private async Task<IEnumerable<TResult>> GetCurrentResultAsync<TResult>(int currentIndex, CancellationToken cancellationToken)
		{
			return (await GetCurrentResultAsync(currentIndex, cancellationToken)).Cast<TResult>();
		}
		private async Task<IEnumerable> GetCurrentResultAsync(int currentIndex, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			return ((IEnumerable) (await (GetResultsAsync(cancellationToken)).ConfigureAwait(false))[currentIndex]);
		}
		protected abstract Task<IList> GetResultsFromAsync(TMultiApproach multiApproach, CancellationToken cancellationToken);
	}
}
