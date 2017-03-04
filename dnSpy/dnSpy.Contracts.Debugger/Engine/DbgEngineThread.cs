﻿/*
    Copyright (C) 2014-2017 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace dnSpy.Contracts.Debugger.Engine {
	/// <summary>
	/// A class that can update a <see cref="DbgThread"/>
	/// </summary>
	public abstract class DbgEngineThread {
		/// <summary>
		/// Gets the thread
		/// </summary>
		public abstract DbgThread Thread { get; }

		/// <summary>
		/// Removes the thread and disposes of it
		/// </summary>
		public abstract void Remove();

		/// <summary>
		/// Properties to update
		/// </summary>
		[Flags]
		public enum UpdateOptions {
			/// <summary>
			/// Update <see cref="DbgThread.Kind"/>
			/// </summary>
			Kind				= 0x00000001,

			/// <summary>
			/// Update <see cref="DbgThread.Id"/>
			/// </summary>
			Id					= 0x00000002,

			/// <summary>
			/// Update <see cref="DbgThread.ManagedId"/>
			/// </summary>
			ManagedId			= 0x00000004,

			/// <summary>
			/// Update <see cref="DbgThread.Name"/>
			/// </summary>
			Name				= 0x00000008,
		}

		/// <summary>
		/// Updates <see cref="DbgThread.Kind"/>
		/// </summary>
		/// <param name="kind">New value</param>
		public void UpdateKind(string kind) => Update(UpdateOptions.Kind, kind: kind);

		/// <summary>
		/// Updates <see cref="DbgThread.Id"/>
		/// </summary>
		/// <param name="id">New value</param>
		public void UpdateId(int id) => Update(UpdateOptions.Id, id: id);

		/// <summary>
		/// Updates <see cref="DbgThread.ManagedId"/>
		/// </summary>
		/// <param name="managedId">New value</param>
		public void UpdateManagedId(int? managedId) => Update(UpdateOptions.ManagedId, managedId: managedId);

		/// <summary>
		/// Updates <see cref="DbgThread.Name"/>
		/// </summary>
		/// <param name="name">New value</param>
		public void UpdateName(string name) => Update(UpdateOptions.Name, name: name);

		/// <summary>
		/// Updates <see cref="DbgThread"/> properties
		/// </summary>
		/// <param name="options">Options</param>
		/// <param name="kind">New <see cref="DbgThread.Kind"/> value</param>
		/// <param name="id">New <see cref="DbgThread.Id"/> value</param>
		/// <param name="managedId">New <see cref="DbgThread.ManagedId"/> value</param>
		/// <param name="name">New <see cref="DbgThread.Name"/> value</param>
		public abstract void Update(UpdateOptions options, string kind = null, int id = 0, int? managedId = null, string name = null);
	}
}
