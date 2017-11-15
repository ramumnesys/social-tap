﻿using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Socialtap.Code.Controller;

namespace Socialtap.Code.View_.Fragments
{
    public class HomeFragment : Fragment
    {
        private View _rootView;
        private TextView topBarName;
        private TextView topBarRate;
        private TextView topBarAvgBeverageVolume;
        private TextView totalAvgBeverageVolume;
        private TextView barCount;
        private TextView reviewCount;


        public static HomeFragment NewInstance()
        {
            return new HomeFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _rootView = inflater.Inflate(Resource.Layout.fragment_home, container, false);
            GetReferencesFromLayout();

            topBarName.Text = MainController.stats.TopBarName;
            topBarRate.Text = MainController.stats.TopBarRate.ToString("0.00");
            topBarAvgBeverageVolume.Text = MainController.stats.TopBarAvgBeverageVolume.ToString("0.00");
            totalAvgBeverageVolume.Text = MainController.stats.TotalAvgBeverageVolume.ToString("0.00");
            barCount.Text = MainController.stats.BarCount.ToString();
            reviewCount.Text = MainController.stats.ReviewCount.ToString();


            return _rootView;
        }

        /// Prideda funkcionalių UI elementų nuorodas 
        private void GetReferencesFromLayout()
        {
            topBarName = _rootView.FindViewById<TextView>(Resource.Id.topBarName);
            topBarRate = _rootView.FindViewById<TextView>(Resource.Id.topBarRate);
            topBarAvgBeverageVolume =_rootView.FindViewById<TextView>(Resource.Id.topBarAvgBeverageVolume);
            totalAvgBeverageVolume = _rootView.FindViewById<TextView>(Resource.Id.totalAvgBeverageVolume);
            barCount = _rootView.FindViewById<TextView>(Resource.Id.barCount);
            reviewCount =_rootView.FindViewById<TextView>(Resource.Id.reviewCount);
        }
    }
}
