﻿using UnityEngine;
using System;
using System.Collections.Generic;

namespace UrMotion
{
	public static class Source
	{
		public static float DefaultFrameRate = 60f;

		public static void ValidateFrameRate(ref float fps)
		{
			if (fps == 0f) {
				fps = DefaultFrameRate;
			}
		}

		public class SourceDimension<V> {}
		public static readonly SourceDimension<float> Float = new SourceDimension<float>();
		public static readonly SourceDimension<float> Single = new SourceDimension<float>();
		public static readonly SourceDimension<Vector2> Vector2 = new SourceDimension<Vector2>();
		public static readonly SourceDimension<Vector3> Vector3 = new SourceDimension<Vector3>();
		public static readonly SourceDimension<Vector4> Vector4 = new SourceDimension<Vector4>();

		public static IEnumerator<V> Constant<V>(V val)
		{
			for (;;) {
				yield return val;
			}
		}

		public static IEnumerator<V> Function<V>(Func<V> f)
		{
			for (;;) {
				yield return f();
			}
		}

		public static IEnumerator<float> Sin(IEnumerator<float> radius, float freq, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (radius.MoveNext()) {
				yield return Mathf.Sin((f / fps) * Mathf.PI * 2f * freq) * radius.Current;
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector2> Sin(IEnumerator<Vector2> radius, float freq, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (radius.MoveNext()) {
				yield return Mathf.Sin((f / fps) * Mathf.PI * 2f * freq) * radius.Current;
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector3> Sin(IEnumerator<Vector3> radius, float freq, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (radius.MoveNext()) {
				yield return Mathf.Sin((f / fps) * Mathf.PI * 2f * freq) * radius.Current;
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector4> Sin(IEnumerator<Vector4> radius, float freq, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (radius.MoveNext()) {
				yield return Mathf.Sin((f / fps) * Mathf.PI * 2f * freq) * radius.Current;
				f += 1.0f;
			}
		}

		public static IEnumerator<float> Cos(IEnumerator<float> radius, float freq, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (radius.MoveNext()) {
				yield return Mathf.Cos((f / fps) * Mathf.PI * 2f * freq) * radius.Current;
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector2> Cos(IEnumerator<Vector2> radius, float freq, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (radius.MoveNext()) {
				yield return Mathf.Cos((f / fps) * Mathf.PI * 2f * freq) * radius.Current;
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector3> Cos(IEnumerator<Vector3> radius, float freq, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (radius.MoveNext()) {
				yield return Mathf.Cos((f / fps) * Mathf.PI * 2f * freq) * radius.Current;
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector4> Cos(IEnumerator<Vector4> radius, float freq, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (radius.MoveNext()) {
				yield return Mathf.Cos((f / fps) * Mathf.PI * 2f * freq) * radius.Current;
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector2> Circular(IEnumerator<float> radius, float speed, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (radius.MoveNext()) {
				var x = Mathf.Cos((f / fps) * Mathf.PI * 2f * speed) * radius.Current;
				var y = Mathf.Sin((f / fps) * Mathf.PI * 2f * speed) * radius.Current;
				yield return new Vector2(x, y);
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector2> Lissajous(IEnumerator<float> A, IEnumerator<float> B, float a, float b, float delta, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (A.MoveNext() && B.MoveNext()) {
				var x = A.Current * Mathf.Cos((f / fps) * Mathf.PI * 2f * a);
				var y = B.Current * Mathf.Sin((f / fps) * Mathf.PI * 2f * b + delta);
				yield return new Vector2(x, y);
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector2> Cycloid(IEnumerator<float> A, IEnumerator<float> B, float rm, float speed, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (A.MoveNext() && B.MoveNext()) {
				var t = (f / fps) * Mathf.PI * 2f * speed;
				var x = A.Current * (rm * (t - Mathf.Sin(t)));
				var y = B.Current * (rm * (1f - Mathf.Cos(t)));
				yield return new Vector2(x, y);
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector2> Epicycloid(IEnumerator<float> A, IEnumerator<float> B, float rc, float rm, float speed, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (A.MoveNext() && B.MoveNext()) {
				var t = (f / fps) * Mathf.PI * 2f * speed;
				var x = A.Current * ((rc + rm) * Mathf.Cos(t) - rm * Mathf.Cos((rc + rm) / rm * t));
				var y = B.Current * ((rc + rm) * Mathf.Sin(t) - rm * Mathf.Sin((rc + rm) / rm * t));
				yield return new Vector2(x, y);
				f += 1.0f;
			}
		}

		public static IEnumerator<Vector2> Hypocycloid(IEnumerator<float> A, IEnumerator<float> B, float rc, float rm, float speed, float fps = 0f)
		{
			ValidateFrameRate(ref fps);
			var f = 0f;
			while (A.MoveNext() && B.MoveNext()) {
				var t = (f / fps) * Mathf.PI * 2f * speed;
				var x = A.Current * ((rc - rm) * Mathf.Cos(t) + rm * Mathf.Cos((rc - rm) / rm * t));
				var y = B.Current * ((rc - rm) * Mathf.Sin(t) - rm * Mathf.Sin((rc - rm) / rm * t));
				yield return new Vector2(x, y);
				f += 1.0f;
			}
		}
	}
}