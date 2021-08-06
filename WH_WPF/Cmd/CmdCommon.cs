﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH_WPF.Cmd
{
	class CmdCommon: ACmd
	{
		private readonly Action<object> _Execute;
		private readonly Func<object, bool> _CanExecute;

		public CmdCommon(Action<object> Execute, Func<object, bool> CanExecute = null)
		{
			_Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
			_CanExecute = CanExecute;
		}

		public override bool CanExecute(object parameter)
		{
			return _CanExecute?.Invoke(parameter) ?? true;
		}


		public override void Execute(object parameter)
		{
			_Execute(parameter);
		}
	}
}
